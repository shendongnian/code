        private Color color;
        private int b;
        public Color Random()
        {
            Random r = new Random();
            b = r.Next(1, 5);
            switch (b)
            {
                case 1:
                    {
                        color = Color.Red;
                    }
                    break;
                case 2:
                    {
                        color = Color.Blue;
                    }
                    break;
                case 3:
                    {
                        color = Color.Green;
                    }
                    break;
                case 4:
                    {
                        color = Color.Yellow;
                    }
                    break;
            }
            return color;
        }
