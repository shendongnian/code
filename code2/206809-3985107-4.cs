           ProcessStartInfo p = new ProcessStartInfo();
           p.Arguments = "your arguments";
           p.FileName = "Application or Document Name";
           Process.Start(p);
    
 
    
        public IList<string> GetMatchingWords(string word)
        {
            var list = new List<string>();
            int levelDepth = 0;
            if (string.IsNullOrEmpty(word))
                return list;
            var tempWord = word[0];
            var firstNode = RootNode.Childs.FirstOrDefault(x => x.Word[0].Equals(tempWord));
            if (firstNode == null)
            {
                return list;
            }
          
            var nodePath = new Queue<TrieNode>();
            var sb = new StringBuilder();
            sb.Append(firstNode.Word);
                        
            
            while (firstNode != null)
            {
                
                levelDepth++;
                if (levelDepth == word.Length)
                {
                    break;
                }
                   
                tempWord = word[levelDepth];
                  firstNode = firstNode.Childs.FirstOrDefault(x => x.Word[0].Equals(tempWord));
                  
                  sb.Append(firstNode.Word);
            }
            if(firstNode!=null)
                nodePath.Enqueue(firstNode);
            originalValue = sb.ToString();
            
            while (nodePath.Any())
            {
                var tempNode = nodePath.Dequeue();
                tempNode.IsParentNode = true;
                PopulateWords(tempNode, sb, ref list);
              
            }
           
            return list;
        }
        private void PopulateWords(TrieNode node,
             StringBuilder sb,ref List<string> list)
        {
          
            if (node.Childs.Any())
            {
                foreach (var temp in node.Childs)
                {
                    if (node.IsParentNode)
                    {
                        sb.Clear();
                        sb.Append(originalValue);
                    }
                    if (temp.Childs.Any())
                    {
                       
                        sb.Append(temp.Word);
                        PopulateWords(temp, sb, ref list);
                          
                    }
                    else
                    {
                        sb.Append(temp.Word);
                        list.Add(sb.ToString());
                    }
                }
            }
            else
            {
                list.Add(sb.ToString());
              
            }
      
        }
