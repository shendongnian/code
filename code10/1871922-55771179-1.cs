    using System;
    using System.Collections;
    using System.Collections.Generic;
    	
    class Clients
    {
        public int client_number;
        public ArrayList accounts; // maybe you ma want to change this to a list<T> as well
    }
    
    class JsonStruct
    {
        public List<Clients> clients;
    }
    
	var obj = new JsonStruct();
    obj.clients[0] = new Clients();
    obj.clients[0].client_number = 100;
