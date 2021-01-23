    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.PowerPacks;
    namespace VBPowerPack
    {
        public partial class Form1 : Form
        {
            private ShapeContainer shapeContainer;  //Container that you're gonna place into your form
            private Shape[] shapes;                 //Contains all the shapes you wanna display
            public Form1()
            {
                InitializeComponent();
                shapes = new Shape[5];              //Let's say we want 5 different shapes
                int posY = 0;
                for (int i = 0; i < 5; i++)
                {
                    OvalShape ovalShape = new OvalShape();      //Create the shape you want with it's properties
                    ovalShape.Location = new Point(50, posY);
                    ovalShape.Size = new Size(75, 25);
                    shapes[i] = ovalShape;                      //Add the shape to the array
                    posY += 30; 
                }
            
                shapeContainer = new ShapeContainer();
                shapeContainer.Shapes.AddRange(shapes);         //Add the array of shapes to the ShapeContainer
                this.Controls.Add(shapeContainer);              //Add the ShapeContainer to your form
            }
        }
    }
