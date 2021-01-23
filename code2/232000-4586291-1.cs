    using System;
    
    namespace ConsoleApplication1
    {
        public interface IEntity { IParent DaddyMommy { get; } }
        public interface IParent : IEntity { }
        public class Parent : Entity, IParent { }
        public class Entity : IEntity
        {
            public IParent DaddyMommy { get; protected set; }
            public IParent AdamEve_Interfaces
            {
                get
                {
                    IEntity e = this;
                    while (this.DaddyMommy != null)
                        e = e.DaddyMommy as IEntity;
                    return e as IParent;
                }
            }
            public Parent AdamEve_Classes
            {
                get
                {
                    Entity e = this;
                    while (this.DaddyMommy != null)
                        e = e.DaddyMommy as Entity;
                    return e as Parent;
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Entity X = new Entity();
                Parent P;
                IParent IP;
                System.Diagnostics.Stopwatch ST = new System.Diagnostics.Stopwatch();
                Int32 i;
    
                ST.Start();
                for (i = 0; i < 10000000; i++)
                {
                    IP = X.AdamEve_Interfaces;
                }
                ST.Stop();
                System.Diagnostics.Trace.WriteLine(ST.ElapsedMilliseconds);
                
                ST.Reset();
    
                ST.Start();
                for (i = 0; i < 10000000; i++)
                {
                    P = X.AdamEve_Classes;
                }
                ST.Stop();
                System.Diagnostics.Trace.WriteLine(ST.ElapsedMilliseconds);
            }
        }
    
    }
