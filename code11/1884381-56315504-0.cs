int[] userInputNumbers = {1,2,3,4,5,6,7};
int[] numbersToCompareTo = {1,9,11,12,4,6,16};
int countOfNumbersThatAreTheSame = 0;
for(int i=0; i<userInputNumbers.Length; i++)
{
   for(int j=0; j<numbersToCompareTo.Length; j++)
   {
       if(userInputNumbers[i] == numbersToCompareTo[j])
       {
           countOfNumbersThatAreTheSame++;
       }
   }
}
Console.Write(countOfNumbersThatAreTheSame);
Console.Read();
