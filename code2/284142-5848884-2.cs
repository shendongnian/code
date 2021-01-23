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
                Attachments = new List<Attachment>();
            }
    
            public void Attach(Attachment attachment)
            {
                Attachments.Add(attachment);
                
                if (attachment.GetType() == typeof(AttachmentA)) {
                    _A = ((AttachmentA)attachment).A;
                }
                else if (attachment.GetType() == typeof(AttachmentB))
                {
                    _B = ((AttachmentB)attachment).B;
                }
            }
    
            public delegate void delegateA();
            public delegate void delegateB();
    
            public delegateA _A;
            public delegateB _B;
    
            public void A()
            {
                if (_A != null)
                {
                    _A();
                }
                else
                {
                    Console.WriteLine("MyClass.A");
                }
            }
            public void B()
            {
                if (_B != null)
                {
                    _B();
                }
                else
                {
                    Console.WriteLine("MyClass.B");
                }
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
