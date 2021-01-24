c#
Console.Write("Input Nomor Menu [1..4]: ");
int pilihan = int.Parse(Console.ReadLine());
Console.WriteLine();
if (pilihan > 0 && pilihan < 5)
{
    Console.Write("Input nilai a = ");
    int a = Convert.ToInt32(Console.ReadLine());
    Console.Write("Input nilai b = ");
    int b = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
    switch (pilihan)
    {
        case 1:
            Console.WriteLine("Hasil Penambahan {0} + {1} = {2}", a, b, 1);
            break;
        case 2:
            Console.WriteLine("Hasil Pengurangan {0} - {1} = {2}", a, b, 2);
            break;
        case 3:
            Console.WriteLine("Hasil Perkalian {0} * {1} = {2}", a, b, 3);
            break;
        case 4:
            Console.WriteLine("Hasil Pembagian {0} / {1} = {2}", a, b, 5);
            break;
        default:
            break;
    }
}
else
{
    Console.WriteLine("Maaf, Menu Yang Anda Pilih Tidak Tersedia");
}
