Console.Write("Probleminizdeki Olay sayisini giriniz:");
int olay = Convert.ToInt32(Console.ReadLine());
Console.Write("Probleminizdeki State sayisini giriniz:");
int state = Convert.ToInt32(Console.ReadLine());
/* Degiskenler */
double[,] matris = new double[olay, state];
double[] maximax = new double[olay];
double[] minimax = new double[olay];
double ebState;
int ebStateSiraSayisi;
/* /Degiskenler */
/* Olay - State Tablosu Taslak Görünümü */
Console.WriteLine();
Console.WriteLine("Olay - State Tablosu Taslak Görünümü");
for (int i=0; i<olay; i++)
{
    Console.Write(i+1+". Olay: ");
    for (int j=0; j<state; j++)
    {
        Console.Write(j+1+". State Değeri -- ");
    }
    Console.WriteLine();
}
/* /Olay - State Tablosu Taslak Görünümü */
/* Olaylar için State değerleri girişi */
for (int i =0; i<olay; i++)
{
    for (int j=0;j<state;j++)
    {
        Console.Write(i + 1 +". Olayın "+ (j+1) +". State değerini giriniz: ");
        matris[i, j] = Convert.ToDouble(Console.ReadLine());
    }
}
/* /Olaylar için State değerleri girişi */
/* Olaylar için State değerleri girişini ekrana yazdırmak */
Console.WriteLine();
for (int i = 0; i < olay; i++)
{
    Console.Write(i + 1 + ". Olay: ");
    for (int j = 0; j < state; j++)
    {
        Console.Write(j+1+". State Değeri: "+matris[i,j]+" --- ");
    }
    Console.WriteLine();
}
/* /Olaylar için State değerleri girişini ekrana yazdırmak */
/* Maximax degerini bulmak */
for (int i = 0; i < olay; i++)
{
    for (int j = 0; j < state; j++)
    {
        if (maximax[i] < matris[i, j])
        {
            maximax[i] = matris[i, j];
        }
    }
}
/* Olaylar icin en yuksek State degerleri */
Console.WriteLine();
for (int i = 0; i < maximax.Length; i++)
{
    Console.WriteLine(i+1+". Olay için en yüksek State degeri: "+maximax[i]);
}
/* En yuksek State degerini secmek */
ebState = maximax[0];
for (int i = 0; i < maximax.Length; i++)
{
    if (maximax[i] > ebState)
    {
        ebState = maximax[i];
        ebStateSiraSayisi = i;
    }   
}
Console.WriteLine();
/* Sonucu yazdırmak */
Console.WriteLine("Maximax kuralina göre " + ebState + " degeri secilir. ");
/* /Maximax degerini bulmak */
Console.ReadLine();
