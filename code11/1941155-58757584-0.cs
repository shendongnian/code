if (value.Length > 50)
{
    Console.WriteLine("You have typed more than 50 characters");
    
    return;
}
courseName = value;
Note that you will also need to handle `null` input, sins string is a nullable type.
So you might want to do something like:
if (value == null)
{
    Console.WriteLine("The course name can not be null.");
}
else if (value.Length > 50)
{
    Console.WriteLine("You have typed more than 50 characters");
}
else
{
    courseName = value;
]
