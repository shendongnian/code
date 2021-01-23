           //error prone to malformed brackets...
            string s = "Hello {0:C} Bye {1} {0} {{34}}";
            
            int param = -1;
            string[] vals = s.Replace("{{", "").Replace("}}", "").Split("{}".ToCharArray());
            for (int x = 1; x < vals.Length-1; x += 2)
            {
                int thisparam;
                string act = vals[x];
                if (Int32.TryParse(act.Split(':')[0], out thisparam) && param < thisparam)
                    param = thisparam;
            }
            //param will be set to the greatest param now.
