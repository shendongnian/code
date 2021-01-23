			using(FileStream fileStream = new FileStream("Sample.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
				fileStream.Seek(GetLastPositionInFile(), SeekOrigin.Begin);
				**Int32 position = 0;**
				using(StreamReader streamReader = new StreamReader(fileStream)) {
					while(!streamReader.EndOfStream) {
						string line = streamReader.ReadLine();
						**position += line.Length;**
						DoSomethingInteresting(line);
						**SaveLastPositionInFile(position);**
						if(CheckSomeCondition()) {
							break;
						}
					}
				}
			}
