    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        static class Program
        {
    
            static void Main(string[] args)
            {
                MyClass aaa = new MyClass();
                aaa.A(); // should print MyClass.A
                aaa.B(); // should print MyClass.B
                aaa.Attach(new AttachmentA());
                aaa.Attach(new AttachmentB());
                aaa.A(); // should print AttachmentA.A <newline> MyClass.A
                aaa.B(); // should print AttachmentB.B
            }
    
        }
    
        class MyClass
        {
            public List<Attachment> Attachments;
    
            public MyClass()
            {
                A = _A;
                B = _B;
                Attachments = new List<Attachment>();
            }
            public void Attach(Attachment attachment)
            {
                Attachments.Add(attachment);
                
                // this is your magic
                if (attachment.GetType() == typeof(AttachmentA)) {
                    A = ((AttachmentA)attachment).A;
                }
                else if (attachment.GetType() == typeof(AttachmentB))
                {
                    B = ((AttachmentB)attachment).B;
                }
            }
    
            public delegate void delegateA();
            public delegate void delegateB();
    
            public delegateA A;
            public delegateB B;
    
            public void _A()
            {
                Console.WriteLine("MyClass.A");
            }
            public void _B()
            {
                Console.WriteLine("MyClass.B");
            }
        }
    
        class Attachment { 
        }
    
        class AttachmentA : Attachment
        {
            public void A()
            {
                Console.WriteLine("AttachmentA.A");
            }
        }
    
        class AttachmentB : Attachment
        {
            public void B()
            {
                Console.WriteLine("AttachmentB.B");
            }
        }
    }
