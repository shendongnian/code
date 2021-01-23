    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
       [StructLayout(LayoutKind.Sequential, Pack = 1)]
       unsafe struct ExampleStruct
       {
          internal const int CField4Length = 18;
    
          public UInt64 Field1;
          public UInt32 Field2;
          public UInt16 Field3;
          public fixed byte Field4[CField4Length];
       }
    
       static unsafe class ExampleStructExtensionMethods
       {
          public static UInt64 GetField1(this byte[] byteArray)
          {
             fixed (byte* byteArrayPointer = &byteArray[0])
             {
                return (*(ExampleStruct*)byteArrayPointer).Field1;
             }
          }
    
          public static UInt32 GetField2(this byte[] byteArray)
          {
             fixed (byte* byteArrayPointer = &byteArray[0])
             {
                return (*(ExampleStruct*)byteArrayPointer).Field2;
             }
          }
    
          public static UInt16 GetField3(this byte[] byteArray)
          {
             fixed (byte* byteArrayPointer = &byteArray[0])
             {
                return (*(ExampleStruct*)byteArrayPointer).Field3;
             }
          }
    
          public static byte[] GetField4(this byte[] byteArray)
          {
             fixed (byte* byteArrayPointer = &byteArray[0])
             {
                byte[] field4 = new byte[ExampleStruct.CField4Length];
                for (int i = 0; i < ExampleStruct.CField4Length; i++)
                   field4[i] = (*(ExampleStruct*)byteArrayPointer).Field4[i];
    
                return field4;
             }
          }
    
          public static void SetField1(this byte[] byteArray, UInt64 field1)
          {
             fixed (byte* byteArrayPointer = &byteArray[0])
             {
                (*(ExampleStruct*)byteArrayPointer).Field1 = field1;
             }
          }
    
          public static void SetField2(this byte[] byteArray, UInt32 field2)
          {
             fixed (byte* byteArrayPointer = &byteArray[0])
             {
                (*(ExampleStruct*)byteArrayPointer).Field2 = field2;
             }
          }
    
          public static void SetField3(this byte[] byteArray, UInt16 field3)
          {
             fixed (byte* byteArrayPointer = &byteArray[0])
             {
                (*(ExampleStruct*)byteArrayPointer).Field3 = field3;
             }
          }
    
          public static void SetField4(this byte[] byteArray, byte[] field4)
          {
             if (field4.Length != ExampleStruct.CField4Length)
                throw new ArgumentException("Byte array must have length 18", "field4");
    
             fixed (byte* byteArrayPointer = &byteArray[0])
             {
                for (int i = 0; i < ExampleStruct.CField4Length; i++)
                   (*(ExampleStruct*)byteArrayPointer).Field4[i] = field4[i];
             }
          }
       }
    
       class TestProgram
       {
          byte[] exampleData =
          {
            // These 8 bytes should go in 'field1'
            0x00,0x01,0x02,0x03,0x04,0x05,0x06,0x07,
            // These 4 bytes should go in 'field2'
            0x08,0x09,0x0A,0x0B,
            // These 2 bytes should go in 'field3'
            0x0C,0x0D,
            // These 18 * 1 bytes should go in 'field4'
            0x0E,0x0F,0x10,0x11,0x12,0x13,0x14,0x15,0x16,0x17,0x18,0x19,0x1A,0x1B,0x1C,0x1D,0x1E,0x1F,
          };
    
          public void TestMethod()
          {
             UInt64 field1 = exampleData.GetField1();
             UInt32 field2 = exampleData.GetField2();
             UInt16 field3 = exampleData.GetField3();
             byte[] field4 = exampleData.GetField4();
    
             exampleData.SetField1(++field1);
             exampleData.SetField2(++field2);
             exampleData.SetField3(++field3);
             exampleData.SetField4(new byte[ExampleStruct.CField4Length] 
               { 0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x42,0x42 });
          }
       }
    }
