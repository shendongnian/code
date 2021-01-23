    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    // add reference to following
    using WindowsInput;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace ConsoleApplicationTester
    {
        class Program
        {
            public static void doLeftMouseClick(int x, int y)
            {
                Cursor.Position = new System.Drawing.Point(x, y);
                InputSimulator.SimulateKeyPress(VirtualKeyCode.LBUTTON);
            }
            public static void doLeftMouseClickEvent(int x, int y, int nr)
            {
                Cursor.Position = new Point(x, y);
                if(nr==1)
                    InputSimulator.SimulateKeyDown(VirtualKeyCode.LBUTTON);
                else
                    InputSimulator.SimulateKeyUp(VirtualKeyCode.LBUTTON);
            }
    
            static void Main(string[] args){
                doLeftMouseClick( 272, 241);
                System.Threading.Thread.Sleep(100);
                doLeftMouseClick( 272, 241);
                InputSimulator.SimulateKeyDown(VirtualKeyCode.MENU);
                doLeftMouseClickEvent(272, 241, 1);
                doLeftMouseClickEvent(529, 242, 2);
                InputSimulator.SimulateKeyUp(VirtualKeyCode.MENU);
                InputSimulator.SimulateKeyDown(VirtualKeyCode.CONTROL);
                InputSimulator.SimulateKeyUp(VirtualKeyCode.VK_C);
                InputSimulator.SimulateKeyUp(VirtualKeyCode.CONTROL);
                // etc.          
            }
        }
    }
