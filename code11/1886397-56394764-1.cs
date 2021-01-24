    string str = null;
            string[] strArr = null;
            int count = 0;
            str = search;
            char[] splitchar = { ' ' };
            strArr = str.Split(splitchar);
            for (count = 0; count <= strArr.Length - 1; count++)
            {
                string i = strArr[count];
                var j = objCon.Mobiles.Where(oh => oh.MobileName.Contains(i) || oh.Description.Contains(i));
                //MessageBox.Show(strArr[count]); 
                foreach (var p in j)
                {
                    Mobiles Mob = new Mobiles();
                    Mob.Description = p.Description;
                    Mob.ImgUrl = p.Url;
                    Mob.MobileName = p.MobileName;
                    Mob.Price = Convert.ToString(p.Price);
                    Mob.SlNo = p.SlNo;
                    prod.Add(Mob);
                }
            }
