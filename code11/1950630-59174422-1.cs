    for(int y = 0; y < cust.Length; y++)
    {
                    if(cust[y] == null)
                    {
                        Customer nc = new Customer();
                        cust[y] = nc;
                        cust[y].GScID = "";
                        cust[y].GSemail = "";
                        cust[y].GSlocation = "";
                        cust[y].GSname = "";
                    }
    
                    str[y] = cust[y].GScID;
    }
    string stringcID = tbCUSTOMERID.Text;
    int found = Array.BinarySearch(str, stringcID);
