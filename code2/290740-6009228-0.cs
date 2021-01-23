        var xmlText = @"
            <level4>
                <module>
                    <moduleCode>ECSC401</moduleCode>
                    <moduleTitle>Programming Methodology</moduleTitle>
                    <credits>15</credits>
                    <semester>1</semester>
                    <assessmentDetails>
                        <assessment>
                            <assessmentName>Test1</assessmentName>
                            <assessmentType>Coursework</assessmentType>
                            <assessmentWeighting>30</assessmentWeighting>
                            <assessmentDueDate></assessmentDueDate>
                        </assessment>
                    </assessmentDetails>
                </module>
            </level4>
            ";
        var xdocument = XDocument.Parse(xmlText);
