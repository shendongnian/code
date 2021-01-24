var stringSplit = text.Split(' ');
            for (int i = 0; i < stringSplit.Length; i++)
            {
                var characters = stringSplit[i].ToCharArray();
                foreach (var character in characters)
                {
                    var keyParams = new KeyParams(VirtualKeyCode.NONAME, character);
                    browser.KeyDown(keyParams);
                    browser.KeyUp(keyParams);
                }
                if (i < stringSplit.Length-1)
                {
                    var spaceKey = new KeyParams(VirtualKeyCode.SPACE, ' ');
                    browser.KeyDown(spaceKey);
                    browser.KeyUp(spaceKey);
                }
            }
