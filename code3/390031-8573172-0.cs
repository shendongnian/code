                if (err == zlibConst.Z_NEED_DICT)
                {
                    byte[] dictionary = System.Text.ASCIIEncoding.ASCII.GetBytes(sDictionary);
                    z.inflateSetDictionary(dictionary, dictionary.Length);
                    err = z.inflate(flush_Renamed_Field);
                }
