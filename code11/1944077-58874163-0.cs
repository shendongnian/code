            Presence pre = null;
            int sum = 0;
            foreach(var cur in presences)
            {
                if(pre != null)
                {
                    foreach(var b in blocks)
                    {
                        if(pre.departure >= b.Start && b.End >=cur.arrival)
                        {
                            sum += (cur.arrival - pre.departure).Minutes;
                            break;
                        }
                    }
                }
                pre = cur;
            }
            Console.WriteLine(sum);//49
