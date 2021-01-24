    using System;
    using Newtonsoft.Json;
    				
    public class Program
    {
    	public static void Main()
    	{
    		string json=@"{'creator_email':'thomas.v@almouj.com','vcard_info':'BEGIN:VCARD\r\nVERSION:2.1\r\nFN;CHARSET=utf-8:Hyder Hafir\r\nTEL;CELL;X-EDIT=0;X-POS=180,175,11,130;CHARSET=utf-8:+96891365444\r\nTEL;WORK;X-EDIT=0;X-POS=240,251,12,139;CHARSET=utf-8:+96824170123\r\nTEL;WORK;X-EDIT=0;X-POS=256,70,13,161;CHARSET=utf-8:2313504\r\nTEL;WORK;FAX;X-EDIT=0;X-POS=258,251,12,140;CHARSET=utf-8:+96824170038\r\nX-IS-TAKE-ADR;CHARSET=utf-8:0;0;\r\nN;X-EDIT=0;X-POS=142,248,15,79;CHARSET=utf-8:Hyder;Hafir ;;;\r\nEMAIL;WORK;X-EDIT=0;X-POS=275,251,15,169;CHARSET=utf-8:oman@telephonyme.com\r\nEXCHANGEDATE:2019-06-17\r\nEXCHANGEDATE:2019-06-17\r\nAUTHOR:IntSig-iOS-iPhone\r\nADR;WORK;X-EDIT=0;X-POS=273,70,30,161,0,0,0,0;CHARSET=utf-8:;;Knowledge Oasis Muscat Muscat, Sultanate Of;;;;Oman\r\nADR;WORK;X-EDIT=0;X-POS=239,70,13,160,0,0,0,0;CHARSET=utf-8:;;First Floor, Office# 0401 Z321;;;;\r\nORG;WORK;X-EDIT=0;X-POS=57,26,11,147,141,157,15,73,158,147,15,203;CHARSET=utf-8:p.p.j L:\/uLmululjqdtu;JJL LLM;Operation Manager I\\\\ilLml Aui\r\nURL;HOMEPAGE;X-EDIT=0;X-POS=293,251,14,150;CHARSET=utf-8:www.telephonyme.com\r\nEND:VCARD','front_jpg':'6X7705UC5b7Kfh8KyBQCC8EV_front.jpg','creator_name':'Thomas Varghese','upload_time':'1560756635574','create_time':'1560756633000'}";
    		var Sresponse = JsonConvert.DeserializeObject<RootObject>(json);
    		Console.WriteLine(Sresponse.creator_email);
    		Console.WriteLine(Sresponse.vcard_info);
    		Console.WriteLine(Sresponse.front_jpg);
    
    	}
    }
    
    public class RootObject
    {
        public string creator_email { get; set; }
        public string vcard_info { get; set; }
        public string front_jpg { get; set; }
        public string creator_name { get; set; }
        public string upload_time { get; set; }
        public string create_time { get; set; }
    }
