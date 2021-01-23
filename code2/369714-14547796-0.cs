              #include<iostream.h>
              #include<conio.h>
              class euler2
                {
                  unsigned long long int a;
                 public:
	            void evensum();
                };
             void euler2::evensum()
              {
                 a=4000000;
                 unsigned  long long int i;
                 unsigned long long int u;
                 unsigned long long int initial=0;
                 unsigned long long  int initial1=1;
                 unsigned long long int sum=0;
              for(i=1;i<=a;i++)
                 {
                      u=initial+initial1;
                      initial=initial1;
                      initial1=u;
                    if(u%2==0)
                       {
                     sum=sum+u;
                        }
                   }
               cout<<"sum of even fibonacci numbers upto 400000 is"<<sum;
             }
                 void main()
                     {
                        euler2 a;
                        clrscr();
                        a.evensum();
                        getch();
                      }
       
