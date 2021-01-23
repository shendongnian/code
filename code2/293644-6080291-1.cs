    //-----------------------------------------------------------------------------
    // <copyright file="Form2.cs" company="DCOM Productions">
    //     Copyright (c) DCOM Productions.  All rights reserved.
    // </copyright>
    //-----------------------------------------------------------------------------
    namespace CrossFormAccess {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
        public partial class Form2 : Form {
            public Form2() {
                InitializeComponent();
            }
            public object[] Items;
            private void DoWork(object sender, EventArgs e) {
                Items = new object[] { "hello", "world" };
                DialogResult = DialogResult.OK;
            }
        }
    }
