    private string getRandColor()
            {
                Random rnd = new Random();
                string hexOutput = String.Format("{0:X}", rnd.Next(0, 0xFFFFFF));
                while (hexOutput.Length < 6)
                    hexOutput = "0" + hexOutput;
                return "#" + hexOutput;
            }
