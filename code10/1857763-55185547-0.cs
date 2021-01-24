    Node n = birdList.headNode;
    Dictionary<string,int> dict = new Dictionary<string,int>();
    while(n!=null){
        if(dict.ContainsKey(n.bird))
        {
            dict[n.bird]++;
        }else{
            dict.Add(n.bird,1);
        }
        n=n.next;
    }
