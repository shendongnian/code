cs
static int[] gradingStudents(int[] grades) 
{
	for (int i = 0; i < grades.Length; i++)
	{
		var item = grades[i];
		if (item >= 38)
		{
			var diff = 5 - (item % 5);
			if (diff < 3)
				grades[i] = item + diff;
		}
	}
	return grades;
}
  [1]: https://www.hackerrank.com/challenges/grading/problem
