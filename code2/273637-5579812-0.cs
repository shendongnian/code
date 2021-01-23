            bool isAbove = false;
            int count = yourList.Count(x =>
            {
                if (x > 1.5 && !isAbove)
                {
                    isAbove = true;
                    return true;
                }
                else if (x < 1.5)
                {
                    isAbove = false;
                }
                return false;
            });
