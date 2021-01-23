                while (true) {
                    var input = Console.ReadLine();
    00000000  push        ebp                    ; setup stack
    00000001  mov         ebp,esp 
    00000003  push        esi  
    00000004  call        6E0208F0               ; Console.In property getter
    00000009  mov         ecx,eax 
    0000000b  mov         eax,dword ptr [ecx] 
    0000000d  call        dword ptr [eax+64h]    ; TextReader.ReadLine()
    00000010  mov         esi,eax                ; assign input variable
                    Console.WriteLine(input);
    00000012  call        6DB7BE38               ; Console.Out property getter
    00000017  mov         ecx,eax
    00000019  mov         edx,esi
    0000001b  mov         eax,dword ptr [ecx] 
    0000001d  call        dword ptr [eax+000000D8h] ; TextWriter.WriteLine()
    00000023  jmp         00000004               ; repeat, note the missing null assigment
