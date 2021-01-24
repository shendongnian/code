    public bool Search(string text)
            {
                Renderer.Markers.Clear();
     
                if (String.IsNullOrEmpty(text))
                {
                    _matches = null;
                    _bounds = null;
                }
                else
                {
                    _matches = Renderer.Document.Search(text, MatchCase, MatchWholeWord);
                    _bounds = GetAllBounds();
                }
     
                _offset = -1;
     
                UpdateHighlights();
     
                return _matches != null && _matches.Items.Count > 0;
            }
