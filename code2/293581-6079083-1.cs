        //-----------------------------------------------------------------------------
        // <copyright file="Employee.cs" company="DCOM Productions">
        //     Copyright (c) DCOM Productions.  All rights reserved.
        // </copyright>
        //-----------------------------------------------------------------------------
        namespace PropertyChangedEventExample {
            using System;
            public class Employee {
                /// <summary>
                /// Expose default constructor
                /// </summary>
                public Employee() {
                    Name = new ObservableObject();
                }
                /// <summary>
                /// Gets or sets the name
                /// </summary>
                public ObservableObject Name {
                    get;
                    set;
                }
            }
        }
