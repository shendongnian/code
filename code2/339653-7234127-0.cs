	using System.Collections.Generic;
	
	public class Block : List<Child> {
		public int ID { get; set; }
		
		public Block(int id) {
			this.ID = id;
		}
	}
	
	public class Child : List<string> {
		
	}
	
	public class Test {
		public static void Main() {
			List<Block> blocks = new List<Block>() {
				new Block(1) {
					new Child() {
						"Hello",
						"World"
					},
					new Child() {
						"One",
						"Two",
						"Three"
					}
				},
				new Block(2) {
					new Child()
				}
			};
	
			string temp = blocks[0][0][0];
			blocks[0][0][0] = blocks[0][0][1];
			blocks[0][0][1] = temp;
		}
	}
