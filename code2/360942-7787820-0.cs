    using System;
    using System.Collections.Generic;
    using System.Text;
    
    class Sample {
        static void Main(string[] args){
            String str = "5 + ( ( 1 + 2 ) *  4 ) -3";
            String result=LengyelFormaKonvertalas(str);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    
        static String LengyelFormaKonvertalas(String input){
           Stack<char> stack = new Stack<char>();
           String str = input.Replace(" ", string.Empty);
           StringBuilder formula = new StringBuilder();
           for (int i = 0; i < str.Length; i++){
               char x=str[i];
               if (x == '(')
                   stack.Push(x);
               else if (x == ')'){
                   while(stack.Count>0 && stack.Peek() != '(')
                       formula.Append(stack.Pop());
                   stack.Pop();
               } else if (IsOperandus(x)){
                   formula.Append(x);
               } else if (IsOperator(x)) {
                   while(stack.Count>0 && stack.Peek() != '(' && Prior(x)<=Prior(stack.Peek()) )
                       formula.Append(stack.Pop());
                   stack.Push(x);
               }
               else {
                  char y= stack.Pop();
                  if (y!='(') 
                      formula.Append(y);
               }
           }
           while (stack.Count>0) {
               formula.Append(stack.Pop());
           }
           return formula.ToString();
        }
    
        static bool IsOperator(char c){
            return (c=='-'|| c=='+' || c=='*' || c=='/');
        }
        static bool IsOperandus(char c){
            return (c>='0' && c<='9' || c=='.');
        }
        static int Prior(char c){
            switch (c){
                case '=':
                    return 1;
                case '+':
                    return 2;
                case '-':
                    return 2;
                case '*':
                    return 3;
                case '/':
                    return 3;
                case '^':
                    return 4;
                default:
                    throw new ArgumentException("Rossz parameter");                                          
            }
        }
    }
