            using(var stdin = process.StandardInput)
            using(var reader = File.OpenText(@"C:\Users\Default\testing.SQL")) {
                string line;
                while((line = reader.ReadLine()) != null) {
                    stdin.WriteLine(line);
                }
                stdin.Close();
            }
