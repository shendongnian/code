        static void Main(string[] args) {
            int[] array = new int[] { 0, 1, 2, 3 };
            for (int ix = 0; ix < array.Length; ++ix) {
                int value = array[ix];
                Console.WriteLine(value);
            }
        }
    Starting at the for loop, ebx has the pointer to the array:
                for (int ix = 0; ix < array.Length; ++ix) {
    00000037  xor         esi,esi                       ; ix = 0
    00000039  cmp         dword ptr [ebx+4],0           ; array.Length < 0 ?
    0000003d  jle         0000005A                      ; skip everything
                    int value = array[ix];
    0000003f  mov         edi,dword ptr [ebx+esi*4+8]   ; NO BOUNDS CHECK !!!
                    Console.WriteLine(value);
    00000043  call        6DD5BE38                      ; Console.Out
    00000048  mov         ecx,eax                       ; arg = Out
    0000004a  mov         edx,edi                       ; arg = value
    0000004c  mov         eax,dword ptr [ecx]           ; call WriteLine()
    0000004e  call        dword ptr [eax+000000BCh] 
                for (int ix = 0; ix < array.Length; ++ix) {
    00000054  inc         esi                           ; ++ix
    00000055  cmp         dword ptr [ebx+4],esi         ; array.Length > ix ?
    00000058  jg          0000003F                      ; loop
