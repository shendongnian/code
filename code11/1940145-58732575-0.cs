    foreach (var page in response.Pages)
                {
                    foreach (var block in page.Blocks)
                    {
                        string box = string.Join(" - ", block.BoundingBox.Vertices.Select(v => $"({v.X}, {v.Y})"));
                        Console.WriteLine($"Block {block.BlockType} at {box}");
                        foreach (var paragraph in block.Paragraphs)
                        {
                            box = string.Join(" - ", paragraph.BoundingBox.Vertices.Select(v => $"({v.X}, {v.Y})"));
                            Console.WriteLine($"  Paragraph at {box}");
                            foreach (var word in paragraph.Words)
                            {
                                Console.WriteLine($"    Word: {string.Join("", word.Symbols.Select(s => s.Text))}");
                            }
                        }
                    }
                }
