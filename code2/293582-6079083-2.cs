        //-----------------------------------------------------------------------------
        // <copyright file="Program.cs" company="DCOM Productions">
        //     Copyright (c) DCOM Productions.  All rights reserved.
        // </copyright>
        //-----------------------------------------------------------------------------
        namespace PropertyChangedEventExample {
            using System;
            class Program {
                static void Main(string[] args) {
                    Employee employee = new Employee();
                    employee.Name.Set("David");
                    employee.Name.ObjectChanged += new EventHandler<EventArgs>(Name_ObjectChanged);
                    employee.Name.Set("Dave");
                    Console.ReadKey(true);
                }
                static void Name_ObjectChanged(object sender, EventArgs e) {
                    ObservableObject employee = sender as ObservableObject;
                    Console.WriteLine("Name changed to {0}", employee.Get());
                }
            }
        }
