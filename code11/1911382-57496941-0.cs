    for(seriesIndex = 1; seriesIndex <= 4; seriesIndex++)
    {
        dataChart.Series["Variable " + seriesIndex].LegendText = controls[seriesIndex - 1].Text;
        //                                                       ^^^^^^^^^^^^^^^^^^^^^^^^^
        //                                                       Like this
        //                                                       Note: arrays start at zero
    }
