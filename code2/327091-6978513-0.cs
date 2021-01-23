	<configSections>
		<sectionGroup name="Environment">
			<sectionGroup name="QA">
				<section name="databases" type="System.Configuration.DictionarySectionHandler"/>
				<section name="storageSystems" type="System.Configuration.DictionarySectionHandler"/>
			</sectionGroup>
			<sectionGroup name="PROD">
				<section name="databases" type="System.Configuration.DictionarySectionHandler"/>
				<section name="storageSystems" type="System.Configuration.DictionarySectionHandler"/>
			</sectionGroup>
		</sectionGroup>
	</configSections>
	<Environment>
		<QA>
			<databases>
			</databases>
			<storageSystems>
			</storageSystems>
		</QA>
		<PROD>
			<databases>
			</databases>
			<storageSystems>
			</storageSystems>
		</PROD>
	</Environment>
