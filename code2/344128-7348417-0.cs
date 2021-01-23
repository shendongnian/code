    var query = (from item in Items.AsEnumerable()
                                                            join grp in groups.AsEnumerable()
                                                              on item.Field<byte>("Group_ID") equals grp.Field<byte>("ID")
                                                              into item_grp_join
                                                              from itemgrp in item_grp_join
                                                              select new
                                                              {
                                                                  ItemName = (string)led.Field<string>("Name"),
                                                                  GName = (string)itemgrp.Field<string>("Name"),
                                                              });
    grid.DataSource = query; // or possible query.ToList() as you suggest in the question!
