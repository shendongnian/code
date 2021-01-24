    private void UpdateHighlights()
            {
                Renderer.Markers.Clear();
     
                if (_matches == null)
                    return;
     
                if (_highlightAllMatches)
                {
                    for (int i = 0; i < _matches.Items.Count; i++)
                    {
                        AddMatch(i, i == _offset);
                    }
                }
                else if (_offset != -1)
                {
                    AddMatch(_offset, true);
                }
            }
     
            private void AddMatch(int index, bool current)
            {
                foreach (var pdfBounds in _bounds[index])
                {
                    var bounds = new RectangleF(
                        pdfBounds.Bounds.Left - 1,
                        pdfBounds.Bounds.Top + 1,
                        pdfBounds.Bounds.Width + 2,
                        pdfBounds.Bounds.Height - 2
                    );
     
                    var marker = new PdfMarker(
                        pdfBounds.Page,
                        bounds,
                        current ? CurrentMatchColor : MatchColor,
                        current ? CurrentMatchBorderColor : MatchBorderColor,
                        current ? CurrentMatchBorderWidth : MatchBorderWidth
                    );
     
                    Renderer.Markers.Add(marker);
                }
            }
