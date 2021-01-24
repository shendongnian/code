                           foreach (StudentInfo item in records)
							{
								csvWriter.WriteField(item.Student.Id);
								csvWriter.WriteField(item.Student.Name);
								foreach (var row in item.Courses)
								{
									csvWriter.WriteField(row.CourseName);
								}
								csvWriter.NextRecord();
							}
