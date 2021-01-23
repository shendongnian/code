			if (File.Exists(@"temp.txt")) File.Delete(@"temp.txt");
			String line;
			String oldLine = "";
			using (var fs = File.OpenRead(largeFileName))
			using (var sr = new StreamReader(fs, Encoding.UTF8, true))
			{
				HashSet<String> hash = new HashSet<String>();
				hash.Add("house");
				using (var sw = new StreamWriter(@"temp.txt"))
				{
					while ((line = sr.ReadLine()) != null)
					{
						foreach (String str in hash)
						{
							if (oldLine.Contains(str))
							{
								sw.WriteLine(oldLine); 
                                // write the next line as well (optional)
								sw.WriteLine(line + "\r\n");									
							}
						}
						oldLine = line;
					}
				}
			}
