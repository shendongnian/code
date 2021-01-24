     btn.Click += delegate
              {
                  fileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "temp.txt");
                  File.WriteAllText(fileName,text.Text );
              };
            btn1.Click += delegate
              {
                  var text = File.ReadAllText(fileName);
                  Console.WriteLine(text);
              };
