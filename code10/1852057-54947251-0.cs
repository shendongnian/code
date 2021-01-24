    allocations = allocations.GroupBy(x => new { x.MANAGER_STRATEGY_ID, x.PRODUCT_ID, x.EVAL_DATE })
                        .Select(group => new FIRMWIDE_MANAGER_ALLOCATION {  EVAL_DATE = group.First().EVAL_DATE,
                                                                            FIRM_ID = group.First().FIRM_ID,
                                                                            FIRM_NAME = group.First().FIRM_NAME,
                                                                            MANAGER_ACCOUNTING_CLASS_ID = group.First().MANAGER_ACCOUNTING_CLASS_ID,
                                                                            MANAGER_ACCOUNTING_CLASS_NAME = group.First().MANAGER_ACCOUNTING_CLASS_NAME,
                                                                            MANAGER_FUND_ID = group.First().MANAGER_FUND_ID,
                                                                            MANAGER_FUND_NAME = group.First().MANAGER_FUND_NAME,
                                                                            MANAGER_FUND_OR_CLASS_ID = group.First().MANAGER_FUND_OR_CLASS_ID,
                                                                            NAV = group.First().NAV,
                                                                            Percent = group.First().Percent,
                                                                            MANAGER_STRATEGY_ID = group.First().MANAGER_STRATEGY_ID,
                                                                            EMV = group.Sum(x => x.EMV),
                                                                            USD_EMV = group.Sum(x => x.USD_EMV),
                                                                            MANAGER_STRATEGY_NAME = group.First().MANAGER_STRATEGY_NAME,
                                                                            PRODUCT_ID = group.First().PRODUCT_ID,
                                                                            PRODUCT_NAME = group.First().PRODUCT_NAME })
                        .ToList();
