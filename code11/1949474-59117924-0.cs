     @for (int x = 0; x < 7; x++)
                                {
                                    <td>
                                        @foreach(var item in Model)
                                        {
                                            if (item.Hours.Contains(i))
                                            {
                                                if(item.Day == days[x]){
                                                    @(item.Class)
                                                    @(item.Classroom)
                                                }
                                                else
                                                {
                                                    @("")
                                                }
                                            }
                                        }
                                    </td>
                                }
