            foreach (char ch in checkers)
            {
                switch (ch)
                {
                    case 'w':
                        Add(new Checker(Color.White, Class.Man));
                        break;
                    case 'W':
                        Add(new Checker(Color.White, Class.King));
                        break;
                    case 'b':
                        Add(new Checker(Color.Black, Class.Man));
                        break;
                    case 'B':
                        Add(new Checker(Color.White, Class.King));
                        break;
                    default:
                        Add(Tile.Empty);
                        break;
                }
            }
