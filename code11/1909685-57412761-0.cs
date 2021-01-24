    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication124
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "BEGIN:VCARD\n" +
                    "VERSION:2.1\n" +
                    "FN;CHARSET=utf-8:s James F ' Ernande.\n" +
                    "ADR;WORK;X-EDIT=0;X-POS=280,43,54,269,0,0,0,0;CHARSET=utf-8:;;P.O. Box No: 570, P. C-112, Ruwi Muscat, Sultanate Ofoman;;;;\n" +
                    "X-IS-TAKE-ADR;CHARSET=utf-8:23.62866567746918;58.26649072858852;\n" +
                    "N;X-EDIT=0;X-POS=33,89,29,178;CHARSET=utf-8:s;James F ' Ernande. ;;;\n" +
                    "EMAIL;WORK;X-EDIT=0;X-POS=116,59,26,237;CHARSET=utf-8:james@om.bluerhine.com\n" +
                    "EMAIL;WORK;X-EDIT=0;X-POS=142,61,26,234;CHARSET=utf-8:oman@onn.bluerhine.com\n" +
                    "EXCHANGEDATE:2019-06-16\n" +
                    "EXCHANGEDATE:2019-06-16\n" +
                    "AUTHOR:IntSig-iOS-iPhone\n" +
                    "ORG;WORK;X-EDIT=0;X-POS=0,0,0,0,59,29,33,295,0,0,0,0;CHARSET=utf-8:;Business Development Manaus)r;\n" +
                    "TEL;WORK;X-EDIT=0;X-POS=88,107,23,142;CHARSET=utf-8:+96897641700\n" +
                    "TEL;WORK;X-EDIT=0;X-POS=332,133,28,182;CHARSET=utf-8:+96822022247\n" +
                    "TEL;WORK;X-EDIT=0;X-POS=328,36,27,92;CHARSET=utf-8:24796647\n" +
                    "END:VCARD";
                ParseVCF parseVCF =  new ParseVCF(input);
            }
        }
        public class ParseVCF
        {
            public string version { get; set; }
            public List<string> data = new List<string>();
            enum State
            {
                FIND_BEGIN,
                GET_VERSION,
                PROCESS_DATA,
                FOUND_END
            }
            public ParseVCF(string input)
            {
     
                StringReader reader = new StringReader(input);
                string line = "";
                State state = State.FIND_BEGIN;
                while(((line = reader.ReadLine()) != null) && (state != State.FOUND_END))
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        switch (state)
                        {
                            case State.FIND_BEGIN :
                                if (line.StartsWith("BEGIN:"))
                                {
                                    state = State.GET_VERSION;
                                }
                                break;
                            case State.GET_VERSION :
                                string[] split = line.Split(new char[] { ':' });
                                version = split[1];
                                state = State.PROCESS_DATA;
                                break;
                            case State.PROCESS_DATA :
                                if(line.StartsWith("END"))
                                {
                                    state = State.FOUND_END;
                                }
                                else
                                {
                                    data.Add(line);
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
