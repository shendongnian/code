      string para = "((())())";
        char[] charPara = para.ToCharArray();
        int charParaCount = charPara.Length;
        Stack<int> myStack = new Stack<int>();      
        int index = 1;
    
        for (int i = 0; i < charParaCount; i++)
        {
            if(charPara[i]=='(')
                myStack.Push(i);
            else if(charPara[i]==')'){
                if(myStack.Pop()==index)//if poped index is what we looking for "==index", currently proccesing index "i" will be corresponding parenthesis to it
                    return i;
            }
        }
