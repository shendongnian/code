    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace FileStreamDatabaseTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                People.OpenCollection();
                People.Test_WillOverwriteData();
                People.CloseCollection();
                Console.ReadLine();
            }
        }
    
        public class Person
        {
            // define maxium variable sizes for serialisation
            protected static int pMaxLength_FirstName = 64;
            protected static int pMaxLength_Age = 10;
            public static int MaxObjectSize
            {
                get
                {
                    // return the sum of all the maxlegnth variables to define the entire object size for serialisation
                    return pMaxLength_FirstName + pMaxLength_Age;
                }
            }
    
            // define each object that will be serialised as follows 
            protected string pFirstName;
            public string Firstname
            {
                set
                {
                    // ensure the new value is not over max variable size
                    if (value.Length > pMaxLength_FirstName)
                        throw new Exception("the length of the value is to long.");
    
                    pFirstName = value;
                }
                get
                {
                    return pFirstName;
                }
            }
            protected int pAge;
            public int Age
            {
                get
                {
                    return pAge;
                }
                set
                {
                    pAge = value;
                }
            }
    
            public byte[] Serialise()
            {
                // Output string builder
                StringBuilder Output = new StringBuilder();
    
                // Append firstname value
                Output.Append(Firstname);
    
                // Add extra spaces to end of string until max length is reached
                if (Firstname.Length < pMaxLength_FirstName)
                    for (int i = Firstname.Length; i < pMaxLength_FirstName; i++)
                        Output.Append(" ");
    
                // Append age value as string
                Output.Append(Age.ToString());
    
                // Add extra spaces to end of string until max length is reached
                int AgeLength = Age.ToString().Length;
                if (AgeLength < pMaxLength_Age)
                    for (int i = AgeLength; i < pMaxLength_Age; i++)
                        Output.Append(" ");
    
                // Return the output string as bytes using ascii encoding
                return System.Text.Encoding.ASCII.GetBytes(Output.ToString());
            }
    
            public void Deserialise(byte[] SerialisedData)
            {
                string Values = System.Text.Encoding.ASCII.GetString(SerialisedData);
    
                pFirstName = Values.Substring(0, pMaxLength_FirstName).Trim();
                pAge = int.Parse(Values.Substring(pMaxLength_FirstName, pMaxLength_Age).Trim());
            }
        }
    
        public static class People
        {
            private static string tileDatasource = @"c:\test.dat";
            private static System.IO.FileStream FileStream;
    
            public static void OpenCollection()
            {
                FileStream = new System.IO.FileStream(tileDatasource, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);
            }
    
            public static void CloseCollection()
            {
                FileStream.Close();
                FileStream.Dispose();
                FileStream = null;
            }
    
            public static void SaveCollection(Person[] People)
            {
                FileStream.SetLength(People.Length * Person.MaxObjectSize);
                FileStream.Position = 0;
    
                foreach (Person PersonToWrite in People)
                {
                    // call serialise to get bytes
                    byte[] OutputBytes = PersonToWrite.Serialise();
    
                    // write the output buffer
                    // note: this will always be the same size as each variable should 
                    //       append spaces until its max size is reached
                    FileStream.Write(OutputBytes, 0, OutputBytes.Length);
                }
            }
    
            public static Person GetValue(int Index)
            {
                // set the stream position to read the object by multiplying the requested index with the max object size
                FileStream.Position = Index * Person.MaxObjectSize;
    
                // read the data
                byte[] InputBytes = new byte[Person.MaxObjectSize];
                FileStream.Read(InputBytes, 0, Person.MaxObjectSize);
    
                // deserialise
                Person PersonToReturn = new Person();
                PersonToReturn.Deserialise(InputBytes);
    
                // retun the person
                return PersonToReturn;
            }
    
            public static void Test_WillOverwriteData()
            {
                long StartTime;
                long EndTime;
                TimeSpan TimeTaken;
    
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("*** Creating 2,000,000 test people... ");
                StartTime = DateTime.Now.Ticks;
                Person[] People = new Person[2000000];
                for (int i = 0; i < 2000000; i++)
                {
                    People[i] = new Person();
                    People[i].Firstname = "TestName." + i;
                    People[i].Age = i;
                }
                EndTime = DateTime.Now.Ticks;
                TimeTaken = new TimeSpan(EndTime - StartTime);
                Console.WriteLine("-> Completed in " + TimeTaken.TotalSeconds + " seconds");
    
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("*** Serialising Collection to disk... ");
                StartTime = DateTime.Now.Ticks;
                SaveCollection(People);
                EndTime = DateTime.Now.Ticks;
                TimeTaken = new TimeSpan(EndTime - StartTime);
                Console.WriteLine("-> Completed in " + TimeTaken.TotalSeconds + " seconds");
    
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("*** Redundancy Test... ");
                StartTime = DateTime.Now.Ticks;
                bool Parsed = true;
                int FailedCount = 0;
                for (int i = 0; i < 2000000; i++)
                {
                    if (GetValue(i).Age != i)
                    {
                        Parsed = false;
                        FailedCount++;
                    }
                }
                EndTime = DateTime.Now.Ticks;
                TimeTaken = new TimeSpan(EndTime - StartTime);
                Console.WriteLine("-> " + (Parsed ? "PARSED" : "FAILED (" + FailedCount + " failed index's"));
                Console.WriteLine("-> Completed in " + TimeTaken.TotalSeconds + " seconds");
    
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("*** Reading 10,000 index's at once... ");
                StartTime = DateTime.Now.Ticks;
                Person[] ChunkOfPeople = new Person[10000];
                for (int i = 0; i < 10000; i++)
                    ChunkOfPeople[i] = GetValue(i);
                EndTime = DateTime.Now.Ticks;
                TimeTaken = new TimeSpan(EndTime - StartTime);
                Console.WriteLine("-> Completed in " + TimeTaken.TotalSeconds + " seconds");
    
    
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("*** Reading 100,000 index's at once... ");
                StartTime = DateTime.Now.Ticks;
                ChunkOfPeople = new Person[100000];
                for (int i = 0; i < 100000; i++)
                    ChunkOfPeople[i] = GetValue(i);
                EndTime = DateTime.Now.Ticks;
                TimeTaken = new TimeSpan(EndTime - StartTime);
                Console.WriteLine("-> Completed in " + TimeTaken.TotalSeconds + " seconds");
    
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("*** Reading 1,000,000 index's at once... ");
                StartTime = DateTime.Now.Ticks;
                ChunkOfPeople = new Person[1000000];
                for (int i = 0; i < 1000000; i++)
                    ChunkOfPeople[i] = GetValue(i);
                EndTime = DateTime.Now.Ticks;
                TimeTaken = new TimeSpan(EndTime - StartTime);
                Console.WriteLine("-> Completed in " + TimeTaken.TotalSeconds + " seconds");
            }
        }     
    }
