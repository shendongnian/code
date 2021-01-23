    using System;
    using System.IO;
    
    public class Class1
    {
        public class MappableObject
        {
            FileStream stream;
    
            public  int Blocks;
            public int BlockSize;
    
            public MappableObject(string FileName, int Blocks_in, int BlockSize_in)
            {
                Blocks = Blocks_in;
                BlockSize = BlockSize_in;
    
                // Just create the file here and set the size
                stream = new FileStream(FileName); // Here we need more params of course to create a file.
                stream.SetLength(sizeof(float) * Blocks * BlockSize);
            }
    
            public float[] GetBlock(int BlockNo)
            {
                long BlockPos = BlockNo * BlockSize;
    
                stream.Position = BlockPos;
    
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    float[] resData = new float[BlockSize];
                    for (int i = 0; i < BlockSize; i++)
                    {
                        // This line is stupid enough for accessing files a lot and the data is large
                        // Maybe someone has an idea to make this faster? I tried a lot and this is the simplest solution
                        // for illustration.
                        resData[i] = reader.ReadSingle();
                    }
                }
    
                retuen resData;
            }
    
            public void SetBlock(int BlockNo, float[] data)
            {
                long BlockPos = BlockNo * BlockSize;
    
                stream.Position = BlockPos;
    
                using (BinaryWriter reader = new BinaryWriter(stream))
                {
                    for (int i = 0; i < BlockSize; i++)
                    {
                        // Also this line is stupid enough for accessing files a lot and the data is large
                        reader.Write(data[i];
                    }
                }
    
                retuen resData;
            }
    
            // For adding two MappableObjects
            public static MappableObject operator +(MappableObject A, Mappableobject B)
            {
                // Of course we have to make sure that all dimensions are correct.
    
                MappableObject result = new MappableObject(Path.GetTempFileName(), A.Blocks, A.BlockSize);
    
                for (int i = 0; i < Blocks; i++)
                {
                    float[] dataA = A.GetBlock(i);
                    float[] dataB = B.GetBlock(i);
    
                    float[] C = new float[dataA.Length];
    
                    for (int j = 0; j < BlockSize; j++)
                    {
                        C[j] = A[j] + B[j];
                    }
    
                    result.SetBlock(i, C);
                }
            }
            
            // For adding a single float to the whole data.
            public static MappableObject operator +(MappableObject A, float B)
            {
                // Of course we have to make sure that all dimensions are correct.
    
                MappableObject result = new MappableObject(Path.GetTempFileName(), A.Blocks, A.BlockSize);
    
                for (int i = 0; i < Blocks; i++)
                {
                    float[] dataA = A.GetBlock(i);
    
                    float[] C = new float[dataA.Length];
    
                    for (int j = 0; j < BlockSize; j++)
                    {
                        C[j] = A[j] + B;
                    }
    
                    result.SetBlock(i, C);
                }
            }
    
            // Of course this doesn't work, but maybe you can see the effect here.
            // when the += is automimplemented from the definition above I have to create another large
            // object which causes a loss of memory and also takes more time because of the operation -> altgough its
            // simple in the example, but in reality it's much more complex.
            public static MappableObject operator +=(MappableObject A, float B)
            {
                // Of course we have to make sure that all dimensions are correct.
    
                MappableObject result = new MappableObject(Path.GetTempFileName(), A.Blocks, A.BlockSize);
    
                for (int i = 0; i < Blocks; i++)
                {
                    float[] dataA = A.GetBlock(i);
    
                    for (int j = 0; j < BlockSize; j++)
                    {
                        A[j]+= + B;
                    }
    
                    result.SetBlock(i, A);
                }
            }
        }
    }
