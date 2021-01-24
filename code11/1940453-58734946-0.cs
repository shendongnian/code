      string para = "((())())";
        int popedIndex;
        char[] charPara = para.ToCharArray();
        int charParaCount = charPara.Length;
        Stack myStack = new Stack();      
        int index = 1;
    
        for (int i = 0; i < charParaCount; i++)
        {
            if(charPara[i]=='(')
                myStack.push(i);
            else if(charPara[i]==')'){
                popedIndex=myStack.pop();
                if(popedIndex==index)//if poped index is what we looking for "==index", currently proccesing index "i" will be corresponding parenthesis to it
                    return i;
            }
        }
