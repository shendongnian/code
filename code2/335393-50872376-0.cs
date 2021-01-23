    Dim gc As New System.Globalization.GregorianCalendar
            Dim d As New DateTime(gc.GetYear(DateTime.Now), 1, 1)
            Dim i As Int16 = 1
            While i <= gc.GetDaysInYear(gc.GetYear(DateTime.Now))
                If gc.GetDayOfWeek(d) = DayOfWeek.Friday Then
                    Response.Write(d & "<br />")
                    d = gc.AddDays(d, 7)
                    i += 7
                Else
                    d = gc.AddDays(d, 1)
                    i += 1
                End If
            End While
