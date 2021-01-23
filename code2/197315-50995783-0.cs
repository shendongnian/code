    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    /// <summary>
    /// 
    /// mauriciogracia@gmail.com
    /// 
    /// </summary>
    namespace VideoUtils.Impl
    {
    
        /// <summary>
        /// Reads the meta information embedded in an FLV byte stream 
        /// </summary>
    
        public class MetaDataStreamReader
        {
    
    
            /// <summary>
            /// Reads the meta information (if present) in an FLV
            /// </summary>
            /// <param name="path">The path to the FLV file</returns>
            public static VideoMetaData GetMetaDataInfo(MemoryStream memStream, string location)
            {
                bool hasMetaData = false;
                double duration = 0;
                double width = 0;
                double height = 0;
                double videoDataRate = 0;
                double audioDataRate = 0;
                Double frameRate = 0;
                DateTime creationDate = DateTime.MinValue;
    
                if(memStream == null)
                {
                    throw new ArgumentNullException("Parameter MemoryStream is null");
                }
    
                try
                {
                    // read where "onMetaData"
                    byte[] bytes = new byte[10];
                    memStream.Seek(27, SeekOrigin.Begin);
                    int result = memStream.Read(bytes, 0, 10);
                    // if "onMetaData" exists then proceed to read the attributes
                    string onMetaData = ByteArrayToString(bytes);
    
                    if (onMetaData == "onMetaData")
                    {
                        hasMetaData = true;
                        // 16 bytes past "onMetaData" is the data for "duration" 
                        duration = GetNextDouble(memStream, 16, 8);
                        // 8 bytes past "duration" is the data for "width"
                        width = GetNextDouble(memStream, 8, 8);
                        // 9 bytes past "width" is the data for "height"
                        height = GetNextDouble(memStream, 9, 8);
                        // 16 bytes past "height" is the data for "videoDataRate"
                        videoDataRate = GetNextDouble(memStream, 16, 8);
                        // 16 bytes past "videoDataRate" is the data for "audioDataRate"
                        audioDataRate = GetNextDouble(memStream, 16, 8);
                        // 12 bytes past "audioDataRate" is the data for "frameRate"
                        frameRate = GetNextDouble(memStream, 12, 8);
                        // read in bytes for creationDate manually
                        memStream.Seek(17, SeekOrigin.Current);
                        byte[] seekBytes = new byte[24];
                        result = memStream.Read(seekBytes, 0, 24);
    
                        /*
                        string dateString = ByteArrayToString(seekBytes);
                        // create .NET readable date string
                        // cut off Day of Week
                        dateString = dateString.Substring(4);
                        // grab 1) month and day, 2) year, 3) time
                        dateString = dateString.Substring(0, 6) + " " + dateString.Substring(16, 4) + " " + dateString.Substring(7, 8);
                        // .NET 2.0 has DateTime.TryParse
                        try
                        {
                            creationDate = Convert.ToDateTime(dateString);
                        }
                        catch { }
                        */
                    }
                }
                catch (Exception )
                {
                    // no error handling
                }
                finally
                {
                    if (memStream != null)
                    {
                        memStream.Close();
                    }
                }
    
                return  VideoMetaData.CreateFlvMetaInfo(hasMetaData, duration, width, height, videoDataRate, audioDataRate, frameRate, creationDate, location);
            }
            private static Double GetNextDouble(MemoryStream memStream, int offset, int length)
            {
                // move the desired number of places in the array
                memStream.Seek(offset, SeekOrigin.Current);
    
                // create byte array
                byte[] bytes = new byte[length];
    
                // read bytes
                int result = memStream.Read(bytes, 0, length);
    
                // convert to double (all flass values are written in reverse order)
                return ByteArrayToDouble(bytes, true);
            }
            private static string ByteArrayToString(byte[] bytes)
            {
                string byteString = string.Empty;
                foreach (byte b in bytes)
                {
                    byteString += Convert.ToChar(b).ToString();
                }
                return byteString;
            }
            private static Double ByteArrayToDouble(byte[] bytes, bool readInReverse)
            {
                if (bytes.Length != 8)
                    throw new Exception("bytes must be exactly 8 in Length");
                if (readInReverse)
                    Array.Reverse(bytes);
                return BitConverter.ToDouble(bytes, 0);
            }
        }
    }
