            private void LoadFile(string p)
            {
                using (var reader = File.OpenText(p))
                {
                    var lineList = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lineList.Add(line);
                    }
                    _lines = lineList.ToArray();
                }
                // Set this to -1 so your first push of next sets the current
                // line to 0 (first element in the array)
                _currentLine = -1;
            }
