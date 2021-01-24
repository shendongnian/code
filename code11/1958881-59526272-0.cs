    //Method to Convert the Structure to byte array
                public byte[] ToByteArray()
                {
                    byte[] b = new byte[LENGTH];
    
                    byte[] Wh_PhnNum_List = new byte[CommandDefine.MAX_SIZE.MAX_WH_PHNNUM_LIST_STR_SZ];
    
                    Wh_PhnNum_List = Common.CharArrayToByteArray(this.Wh_PhnNum_List);
    
                    Buffer.BlockCopy(Wh_PhnNum_List, 0, b, 0, CommandDefine.MAX_SIZE.MAX_WH_PHNNUM_LIST_STR_SZ);
                    return b;
                }
