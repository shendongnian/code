	public static void Main() {
		RandomNumberGenerator rnd = RandomNumberGenerator.Create();
		byte[] input = new byte[20];
		rnd.GetBytes(input);
		Console.WriteLine("Input Data: " + BytesToStr(input));
	
		var hashAlgoTypes = Assembly.GetAssembly(typeof(HashAlgorithm)).GetTypes()
			.Where(t => typeof(HashAlgorithm).IsAssignableFrom(t) && !t.IsAbstract);
	
		foreach (var hashType in hashAlgoTypes) 
			new AlgoTester(hashType).AssertOkFor(input.ToArray());
	}
	
	public static string BytesToStr(byte[] bytes) {
		StringBuilder str = new StringBuilder();
	
		for (int i = 0; i < bytes.Length; i++)
			str.AppendFormat("{0:X2}", bytes[i]);
	
		return str.ToString();
	}
	public class AlgoTester {
		readonly byte[] key;
		readonly Type type;
		public AlgoTester(Type type) {
			this.type=type;
			if (typeof(KeyedHashAlgorithm).IsAssignableFrom(type))
				using(var algo = (KeyedHashAlgorithm)Activator.CreateInstance(type))
					key = algo.Key.ToArray();
		}
		public HashAlgorithm MakeAlgo() {
			HashAlgorithm algo = (HashAlgorithm)Activator.CreateInstance(type);
			if (key != null)
				((KeyedHashAlgorithm)algo).Key = key;
			return algo;
		}
	
		public byte[] GetHash(byte[] input) {
			using(HashAlgorithm sha = MakeAlgo())
				return sha.ComputeHash(input);
		}
	
		public byte[] GetHashOneBlock(byte[] input) {
			using(HashAlgorithm sha = MakeAlgo()) {
				sha.TransformFinalBlock(input, 0, input.Length);
				return sha.Hash;
			}
		}
	
		public byte[] GetHashMultiBlock(byte[] input, int size) {
			using(HashAlgorithm sha = MakeAlgo()) {
				int offset = 0;
				while (input.Length - offset >= size)
					offset += sha.TransformBlock(input, offset, size, input, offset);
				sha.TransformFinalBlock(input, offset, input.Length - offset);
				return sha.Hash;
			}
		}
	
		public byte[] GetHashMultiBlockInChunks(byte[] input, int size) {
			using(HashAlgorithm sha = MakeAlgo()) {
				int offset = 0;
				while (input.Length - offset >= size)
					offset += sha.TransformBlock(input.Skip(offset).Take(size).ToArray()
						, 0, size, null, -24124512);
				sha.TransformFinalBlock(input.Skip(offset).ToArray(), 0
					, input.Length - offset);
				return sha.Hash;
			}
		}
	
		public void AssertOkFor(byte[] data) {
			var direct = GetHash(data);
			var indirect = GetHashOneBlock(data);
			var outcomes =
				new[] { 1, 2, 3, 5, 10, 11, 19, 20, 21 }.SelectMany(i =>
					new[]{
						new{ Hash=GetHashMultiBlock(data,i), Name="ByMSDN"+i},
						new{ Hash=GetHashMultiBlockInChunks(data,i), Name="InChunks"+i}
					}).Concat(new[] { new { Hash = indirect, Name = "OneBlock" } })
				.Where(result => !result.Hash.SequenceEqual(direct)).ToArray();
			Console.Write("Testing: " + type);
	
			if (outcomes.Any()) {
				Console.WriteLine("not OK.");
				Console.WriteLine(type.Name + " direct was: " + BytesToStr(direct));
			} else Console.WriteLine(" OK.");
	
			foreach (var outcome in outcomes)
				Console.WriteLine(type.Name + " differs with: " + outcome.Name + " "
					+ BytesToStr(outcome.Hash));
		}
	}
