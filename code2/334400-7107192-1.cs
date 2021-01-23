    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace StackOverflowTest
    {
    	[TestClass]
    	public class ByteTest
    	{
    		private bool FindEndMark(byte[] source, int index, out int size)
    		{
    			int endIndex = index + 3;
    			if (endIndex > source.Count())
    			{
    				// need to cope with the fact that the datapacket might be shorter than the MBus message.
    				throw new Exception("end count > length of array");
    			}
    
			if (source[endIndex] == 0x68)
			{
				// According to the updated spec, the size is emitted twice as a verification
				if (source[index + 1] == source[index + 2])
				{
					size = source[index] + 1;
					return true;
				}
			}
    			size = 0;
    			return false;
    		}
    
    		[TestMethod]
    		public void FindMbusDatagram()
    		{
    			byte[] src = new byte[]
    				{
    					// Random junk to start
    					00, 01, 02, 03, 04, 05, 06, 07, 08, 09, 0xa, 0xb, 0xc, 0xd, 
    					// An MBus Packet
    					0x68, 06, 00, 0x68, 08, 05, 72, 00, 00, 00, 
    					// More junk
    					00, 00, 00, 0x16, 00, 00, 00, 00, 01, 
    					// Put a rogue 0x68 in so we can prove we don't get false positives in the datastream
    					0x68, 03, 04, 05, 06, 07, 08, 09, 0xa, 0xb, 0xc, 0xd,
    					// Another Packet
    					0x68, 01, 00, 0x68, 0xFF,
    					//final junk
    					 00, 16, 00, 00, 00, 01, 02, 03
    				};
    
    			List<byte[]> packets = new List<byte[]>();
    
    			for (int i = 0; i < src.Length; i++ )
    			{
    				if (src[i] != 0x68)
    				{
    					continue;
    				}
    				else
    				{
    					int packetSize = 0;
    					if (FindEndMark(src, i, out packetSize))
    					{
    						if (packetSize > (src.Length - i))
    						{
    							// read more data from your port and append it somehow.
    						}
    						else
    						{
    							// We're packetSize+4 includes the header information + checksum and end
							// NB: packetSize+5 is a checksum byte
							// NB: packetSize+6 should be 0x16 according to the MBus spec.
    							byte[] packet = new byte[packetSize + 4];
    							int count = 0;
    
    							// Copy the packet + header into a byte[]
    							for (int j = i; j < (i + packetSize + 4); j++)
    							{
    								packet[count++] = src[j];
    							}
    
    							packets.Add(packet);
    
    							// Move the counter along
    							i += (packetSize + 4);
    						}
    					}
    				}
    			}
    
    			// Should have two packets here.
    			Assert.IsTrue(packets.Count > 0);
    		}
    	}
    }
