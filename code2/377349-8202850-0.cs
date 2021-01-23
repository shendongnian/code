          if (pNumber.Length > 7)
            {
                pNumber = string.Format("3897{0}", pNumber.Substring(pNumber.Length - 7, 7));
            }
            else
            {
                pNumber = string.Format("3897{0}", pNumber);
            }
