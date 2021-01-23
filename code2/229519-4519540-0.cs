     class BitMask {
         private IBitMaskData actual;
         public void SetBitIndex(int index) {
              actual = actual.SetBitIndex(index);
         }
     }
     // Stuff below is an implementation detail of class BitMask
     // and private
     interface IBitMaskData {
          ...
          IBitMaskData SetBitIndex(int index);
     }
     class SmallBitMask {
          IBitMaskData SetBitIndex(int index) {
              if( index < 64 ) { 
                  // Set the bit actually...
                  return this;
              } else {
                  LargeBitMask newMask = new LargeBitMask(this);
                  return newMask.SetBitIndex(index);
              }
          }
     }
     class LargeBitMask {
         ...
     }
