double avg = 0;
for (int i = 0; i < arr.Length; i++) // arr.Length should be the same as MaxRate
{
    avg += arr[i] * (i + MinRate);
}
avg /= arr.length;
</pre>
