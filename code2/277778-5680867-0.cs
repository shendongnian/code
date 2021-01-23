        {
            char[] input = txtInput.Text.ToCharArray();
            StringBuilder sbResult = new StringBuilder();
            foreach (char c in input)
            {
                int asciiCode = (int)c;
                if (
                    //Space
                    asciiCode == 32
                    ||
                    // Period (.)
                    asciiCode == 46
                    ||
                    // Percentage Sign (%)
                    asciiCode == 37
                    ||
                    // Underscore
                    asciiCode == 95
                    ||
                    ( //0-9, 
                        asciiCode >= 48
                        && asciiCode <= 57
                    )
                    ||
                    ( //A-Z
                        asciiCode >= 65
                        && asciiCode <= 90
                    )
                    ||
                    ( //a-z
                        asciiCode >= 97
                        && asciiCode <= 122
                    )
                )
                {
                    sbResult.Append(c);
                }
            }
            txtResult.Text = sbResult.ToString();
        }
