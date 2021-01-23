            private void LoadFile(string file)
            {
                using (var reader = File.OpenText(file))
                {
                    _lines = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        _lines.Add(line);
                    }
                }
                // Set this to -1 so your first push of next sets the current
                // line to 0 (first element in the array)
                _currentLine = -1;
            }
