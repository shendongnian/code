    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Projecttest
    {
        class Program
        {
            struct student
            {
                public string stid;
                public string stname;
                public string stage;
    
            };
            static void Main(string[] args)
            {
                student[] st = new student[4];
                int choice;
                string confirm;
    
                int count = 0;
                Console.WriteLine("Select operation to Perform");
                Console.WriteLine("1. ADD");
                Console.WriteLine("2. UPDATE");
                Console.WriteLine("3. DELETE");
                Console.WriteLine("4. SHOW");
                do
                {
                    Console.Write("enter your choice(1-4):");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Add(st, count);
                            count++;
                            break;
                        case 2:
                            Update(st);
                            break;
                        case 3:
                            Delete(st);
                            break;
                        case 4:
                            Show(st);
                            break;
                        default:
                            Console.WriteLine("\nInvalid Selection\n");
                            break;
                    }
    
                    Console.Write("Press Y or y to continue:");
    
                    confirm = Console.ReadLine().ToString();
                } while (confirm == "Y" || confirm == "y");
            }
    
            static void Add(student[] st, int count)
            {
                Console.Write("\nEnter student ID: ");
                st[count].stid = Console.ReadLine();
                Console.Write("Enter student name: ");
                st[count].stname = Console.ReadLine();
                Console.Write("Enter student age: ");
                st[count].stage = Console.ReadLine();
            }
            static void Show(student[] st)
            {
                for (int count = 0; count < st.Length; count++)
                {
                    if (st[count].stid != null)
                    {
                        Console.WriteLine("\nStudent ID : " + st[count].stid);
                        Console.WriteLine("Student Name : " + st[count].stname);
                        Console.WriteLine("Student Age : " + st[count].stage);
                    }
                }
            }
            static void Delete(student[] st)
            {
                Console.Write("\nEnter student ID: ");
                string studid = Console.ReadLine();
                for (int count = 0; count < st.Length; count++)
                {
                    if (studid == st[count].stid)
                    {
                        st[count].stid = null;
                        st[count].stname = null;
                        st[count].stage = null;
                    }
                }
            }
            static void Update(student[] st)
            {
                Console.Write("\nEnter student ID: ");
                string studid = Console.ReadLine();
                for (int count = 0; count < st.Length; count++)
                {
                    if (studid == st[count].stid)
                    {
                        Console.Write("Enter student name: ");
                        st[count].stname = Console.ReadLine();
                        Console.Write("Enter student age: ");
                        st[count].stage = Console.ReadLine();
                    }
                }
            }
        }
    }
