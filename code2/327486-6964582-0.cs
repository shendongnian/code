        public void CreateSrgsNodes(Action<SrgsElement> addSrgsChild, CurrentNode)
        {
            foreach (GmlModel gmlModel in gmlModels)
            {
               
                if (<Pseudo Code: Is CurrentNode of type SrgsItem>)
                {
                    var srgsOneOf = new SrgsOneOf();
                    addSrgsChild(srgsOneOf);
                    //Note: Arg1 is type SrgsElement
                    CreateSrgsNodes(srgsOneOf.Add, CurrenNode.getChild);
                }
                if (<Pseudo Code: Is CurrentNode of type SrgsOneOf>)
                {
                    var srgsOneOf = new SrgsOneOf();
                    addSrgsChild(srgsOneOf);
                    //Note: Arg1 is type SrgsItem (FAILS without overload CreateSrgsNodes(Action<SrgsItem>, CurrentNode))
                    CreateSrgsNodes(srgsOneOf.Add,CurrenNode.getChild); created
                }
            }
        }
